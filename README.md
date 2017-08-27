Fluent interface for BDD style testing

# Reason
I had used SpecFlow for BDD style testing in the past, but found the tooling too heavy, with dependencies on extensions and external tools.
This is especially annoying for people working on different OSes or toolchains.

# Goal
I wanted to preserve the setup of a SpecFlow style test, but all the tooling is simple C#. I have no particular need for Cucumber in my projects. (If you need cucumber, this is not the interface for you).
I have Given, When, Then, and And definitions, each mutating a shared test context, with assertions validating the state of that context at the end of the run. You can use whatever assertion framework you prefer.

# Use
