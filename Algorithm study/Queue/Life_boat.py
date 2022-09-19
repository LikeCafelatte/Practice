# 구명보트
# https://school.programmers.co.kr/learn/courses/30/lessons/42885#

from collections import deque
def solution(people, limit):
    res = 0
    people.sort(reverse = True)
    dq = deque(people)
    while dq:
        a = limit - dq.popleft()
        while dq and dq[-1] <= a:
            dq.pop()
            break
        res += 1
    return res
