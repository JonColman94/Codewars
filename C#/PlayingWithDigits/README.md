# Playing with Digits

Some numbers have funny properties. For example:

89 --> 8[G¹ + 9[G² = 89 * 1

695 --> 6[G² + 9[G³ + 5[G⁴= 1390 = 695 * 2

46288 --> 4[G³ + 6[G⁴+ 2[G⁵ + 8[G⁶ + 8[G[G⁷ = 2360688 = 46288 * 51

Given a positive integer n written as abcd... (a, b, c, d... being digits) and a positive integer p

we want to find a positive integer k, if it exists, such as the sum of the digits of n taken to the successive powers of p is equal to k * n.
In other words:

Is there an integer k such as : (a ^ p + b ^ (p+1) + c ^(p+2) + d ^ (p+3) + ...) = n * k

If it is the case we will return k, if not return -1.

Note: n and p will always be given as strictly positive integers.
