# 야근 지수
# https://school.programmers.co.kr/learn/courses/30/lessons/12927?language=python3

import heapq
def solution(n, works):
    works = [-w for w in works]
    works.sort()
    for i in range(n):
        p = heapq.heappop(works)
        if p == 0:
            return 0
        p += 1
        n -= 1
        heapq.heappush(works, p)
    answer = sum([w ** 2 for w in works])
    return answer
