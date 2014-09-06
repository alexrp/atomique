# Atomique

Sane atomic operations for .NET based on the C++11 memory model.

This library is based on the information in
[this blog post](http://blog.alexrp.com/2014/03/30/dot-net-atomics-and-memory-model-semantics)
and provides an understandable atomic operations API based on the C++11 memory
model (with some simplifications for the Common Language Infrastructure). The
goal is that users should be able to write lock-free data structures and
algorithms without having to resort to the `Thread.VolatileRead` and
`Thread.VolatileWrite` methods, nor the `Interlocked` and `Volatile` classes.
