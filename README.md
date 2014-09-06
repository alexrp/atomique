# Atomique

Sane atomic operations for .NET based on the C++11 memory model.

This library is based on the information in
[this blog post](http://blog.alexrp.com/2014/03/30/dot-net-atomics-and-memory-model-semantics)
and provides an understandable atomic operations API based on the C++11 memory
model (with some simplifications for the Common Language Infrastructure). The
goal is that users should be able to write lock-free data structures and
algorithms without having to resort to the `Thread.VolatileRead` and
`Thread.VolatileWrite` methods, nor the `Interlocked` and `Volatile` classes.

## FAQ

### Why the C++11 memory model?

In short: Because it's becoming ubiquitous. C++11, C11, D, Rust, and many other
languages, old and new alike, are picking up this memory model. This means that
many programmers will be familiar with it and there is plenty of documentation
on it.

There is also the empirical evidence that making an atomic operations API not
based on the C++11 memory model leads to a complexity disaster, as described in
the blog post this library is based on.

### Which barrier kind should I use?

I recommend reading
[this `memory_order` C++ documentation](http://en.cppreference.com/w/cpp/atomic/memory_order)
and applying that to whatever problem you're solving. The answer to the
question completely depends on what you're doing, and there's no good, generic
answer.

That being said, if you're still in doubt after having read that page, you can
simply use sequential consistency barriers and you should be fine in 99% of
cases. Your code will end up a bit slower than necessary, but it's not by all
that much.

### Why are some barriers stronger than specified?

Any given operation is guaranteed to use the specified barrier, or a barrier
that is strictly a superset of the specified barrier. In the latter case, the
barrier is stronger than strictly necessary, which can cause slight visible
slowdowns.

Overly strong barriers are a direct consequence of the limited atomics API
surface of the .NET Framework.

### Why are some methods missing for 8-bit and 16-bit types?

The main reason is that there are no methods in the framework for doing atomic
add, subtract, or CAS on 8-bit and 16-bit types. Without CAS, add and subtract
can't even be implemented with a somewhat slow CAS loop.

These operations also cannot be implemented with locks, because then all other
methods for 8-bit and 16-bit data would have to synchronize on that lock,
slowing everything down.

It sucks, but consider using 32-bit and 64-bit data instead.

### Why are there no AND/OR/XOR methods?

The reason is similar to the lack of add and subtract operations for 8-bit and
16-bit types: The .NET Framework doesn't provide anything out of the box to do
these operations.

These could be implemented with a CAS loop, at least for 32-bit and 64-bit
types. This may be done in a future version of Atomique.

### Why are weak CAS operations not supported?

Three reasons:

1. There is no evidence to suggest that weak CAS is particularly useful.
2. There is no mapping to any .NET Framework method that would have different
   semantics than a regular CAS.
3. All known C++11 `compare_and_exchange_weak` implementations at this time
   just map to the regular `compare_and_exchange_strong`.

### Why do CAS methods only specify one barrier?

In C++11, two barriers can be given to `compare_and_exchange_strong`. One is
the barrier to use for the read-modify-write operation (if the value at the
memory location compares equal to the comparand), and the other is the
barrier to use for the load operation (in the case where the value at the
memory location is not equal to the comparand).

There's no particular reason that the Atomique API couldn't support this, but
in practice, it's easier to reason about a single memory order for the whole
operation.

### Why does Atomique use both `Interlocked` and `Volatile`?

As bad as it is to rely on these classes to synchronize on the same lock, it is
the only option with the current atomic APIs in the .NET Framework.

The good news is that both Microsoft .NET and Mono do this.

### Why is there no signal/compiler barrier?

C++11 has the `atomic_signal_fence` function which does nothing at runtime, but
prevents the compiler from reordering memory operations as specified by the
barrier kind. The reason Atomique doesn't have this is two-fold.

First, there is no reliable way to insert a compiler barrier in C#/.NET. Some
misguided libraries use the `[MethodImpl(MethodImplOptions.NoOptimization)]`
attribute to try to get this effect, but this is not actually guaranteed to
have *any* effect in a given CLI implementation. Worse, with the vague wording
of the `NoOptimization` option, there's no guarantee that it will do what a
compiler barrier requires.

Second, signals can only be delivered to a .NET application by using a library
like `Mono.Posix` on POSIX systems. This library only exposes signals as events
that can be waited on; signals don't actually interrupt execution at arbitrary
points. This makes a compiler barrier unnecessary as asynchronous suspension
of a running thread by a signal is the only reason `atomic_signal_fence` exists
in C++11.

### Why is there no consume barrier?

This one is easy: Simplicity. This is quite possibly the hardest-to-understand
barrier in the C++11 memory model and anecdotal evidence suggests that it's
rarely (if ever) used in real code.

### Does Atomique support volatile (as in C/C++) variables?

No. This has nothing to do with atomics and therefore is not something Atomique
tries to deal with.

There is a common misconception that `volatile` is related to atomicity. This
is likely caused by Java and C# assigning a completely different meaning to the
`volatile` keyword than C and C++ do. The Microsoft C/C++ compiler on x86 and
x86-64 also treats `volatile` the same way that C# does.

To be clear: `volatile` *has nothing to do with with atomics in the standard
C/C++ sense*. If what you want is actually atomicity and/or acquire and release
memory ordering -- i.e. you want C# or Java semantics -- then Atomique fits the
bill. But if what you're looking for is the C/C++ `volatile` which is used to
inhibit compiler optimization, Atomique is not the library you need.

### Why does Atomique contain unsafe code?

This is necessary for some unsafe pointer casts in e.g. `Atomic.Char` and
`Atomic.UInt32`. The .NET Framework is missing a lot of overloads, so casting
to a different integer type (with the same size) is the only way to implement
these operations.
