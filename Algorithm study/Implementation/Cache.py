# [1차] 캐시
# https://school.programmers.co.kr/learn/courses/30/lessons/17680

from collections import deque
def solution(cacheSize, cities):
    answer = 0
    cache = deque()
    if cacheSize == 0:
        return len(cities) * 5
    for city in map(lambda x : x.lower(), cities):
        if city in cache:
            answer += 1
            cache.remove(city)
        else:
            answer += 5
        if len(cache) < cacheSize:
            cache.append(city)
        else:
            cache.popleft()
            cache.append(city)
    return answer