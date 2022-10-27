# 삼총사
# https://school.programmers.co.kr/learn/courses/30/lessons/131705

import itertools
def solution(number):
    answer = 0
    for a, b, c in itertools.combinations(number, 3):
        if a + b + c == 0:
            answer += 1
    return answer