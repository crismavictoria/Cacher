# Welcome

Hi,

Thanks for signing up for the chance to work at [rise-x.io](https://rise-x.io).

This is a small coding challenge that should take you an hour or so.

# Challenge

### Required
In order to complete this challenge you must:

* ✅ Unzip the project file
* ✅ Build Project
* ✅ Fix All Build Errors
* ✅ Answer all <questions> in the code
* ✅ Refactor code
* ✅ Implement Super Fast Cache x1000 times quicker

### Optional
* Implement a generic version of the cache and run the test using Company object instead of Employee.

# Questions

You will find through the code ```<question>``` tags, can you please fill your answer into the ```<answer>``` section below the question.

If you don't understand the question or are unsure please indicate in the answer.

# Background

The sample code is a test bed for a cache, the idea is that we store 1 million records in memory and we need a super fast way to retrieve these records, the current implementation was done by our junior developer and is super slow.

Your job is to review the code and refactor as required, by refactoring the code you will demonstrate to the junior developer what great code looks like.

By running the code you will get the following, we will be comparing the times between the slow run and fast run, we want it super fast!

``` text
Super Slow Cache x1000 slower that it should be 🙁

First Item  3.100  (found=True ) | min:      291808 ticks | avg ms per find:      0.01 ms | max:     2206082 ticks | #Tests:   3 | Total Time:       2 ms |
Mid Item    3.100  (found=True ) | min:  1994417127 ticks | avg ms per find:     20.53 ms | max:  2100972438 ticks | #Tests:   3 | Total Time:    6160 ms |
Last Item   3.100  (found=True ) | min:  3775112800 ticks | avg ms per find:     38.52 ms | max:  3905364959 ticks | #Tests:   3 | Total Time:   11556 ms |
```

The test harness looks for the first, mid and last items in the collection of a 1,000,000 items. The test runs 100 times to get an average for each find result.


Good luck!

Regards,


Rise Development Team
Feb 2022