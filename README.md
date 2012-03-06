# Approval Test Demos #


### Setup ###

Install using nuget 
install-package ApprovalTests
Adds 2 assemblies, ApprovalTests & ApprovalUtilities

Install [TortoiseMerge](http://tortoisesvn.net/downloads.html)
*Have to install tortoise svn too? sad panda*

### IMPORTANT ###
If you are verifying a single proparty like customer.Fullname() make sure
to put a new line at the end in your call to .Verify otherwise the diff / merge
tools get confused about line endings.

### Features ###
Verify - Verify a single value, just need to override ToString()
VerifyAll - Verify a list of values
?Can add use your own diff reporter with AddDiffReporter?

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

