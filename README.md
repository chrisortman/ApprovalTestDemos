# Approval Test Demos #

## Abstract ##
ApprovalTests is a way of defining expectations for tests.
But instead of specifying your expectations up front and then coding until they are met
you gradually build the expectation and when you are satisfied you _lock it down_

This proves to be very useful when 

* changes to existing code with little to no tests
* producing public angle bracket ish api's
* input -> processing -> output verification
* produce reports that trace code execution

### Setup ###

Install using nuget 
install-package ApprovalTests
Adds 2 assemblies, ApprovalTests & ApprovalUtilities

Install [TortoiseMerge](http://tortoisesvn.net/downloads.html)
*Have to install tortoise svn too? sad panda*

Add *.received.* to your .gitignore

### IMPORTANT ###
If you are verifying a single property like customer.Fullname() make sure
to put a new line at the end in your call to .Verify otherwise the diff / merge
tools get confused about line endings.

### Features ###
Verify - Verify a single value, just need to override ToString()
VerifyAll - Verify a list of values
?Can add use your own diff reporter with AddDiffReporter?
Can put reporter at the class level

### Testing Glossary

Unit Tests
Test things in isolation

Integration Tests
Uses your infractructure
Tests things from end-to-end

Acceptance Tests
Written in language of the customer
Given / When / Then
As a / I want / So that

Goal of these is to verify correctness

TDD/BDD
Used to guide your design

