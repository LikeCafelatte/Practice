# 야간 전술 보행
# https://school.programmers.co.kr/learn/courses/30/lessons/133501

def solution(distance, scope, times):
    guard = [[0, 1] for _ in range(distance + 1)]
    for idx, val in enumerate(scope):
        a, b = min(val), max(val)
        for i in range(a, b + 1):
            guard[i] = times[idx]
    for idx, time in enumerate(guard):
        if 0 < idx % sum(time) <= time[0]:
            return idx
    return distance
