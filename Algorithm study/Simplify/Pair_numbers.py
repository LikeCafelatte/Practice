# 숫자 짝꿍
# https://school.programmers.co.kr/learn/courses/30/lessons/131128

from collections import Counter
def solution(X, Y):
    answer = ''
    counters = Counter(X) - (Counter(X) - Counter(Y))
    if len(counters) == 1 and counters["0"] != 0:
        return "0"
    elif counters:
        for c in sorted(counters, reverse = True):
            answer += c * counters[c]
    else:
        return "-1"
    return answer