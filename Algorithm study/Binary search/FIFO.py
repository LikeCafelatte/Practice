# 선입 선출 스케쥴링
# https://school.programmers.co.kr/learn/courses/30/lessons/12920

import math
def solution(n, cores):
    high, low = n * min(cores), 1
    while high > low:
        mid = (high + low ) // 2
        temp = 0
        for core in cores:
            temp += mid // core + 1
            if temp > n:
                break
        if temp < n:
            low = mid + 1
        else:
            high = mid
    n -= sum([math.ceil(low / core) for core in cores])
    for idx, val in enumerate(cores):
        if low % val == 0:
            n -= 1
        if n == 0:
            return idx + 1
    return n