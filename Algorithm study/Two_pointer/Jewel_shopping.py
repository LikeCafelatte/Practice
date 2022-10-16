# 보석 쇼핑
# https://school.programmers.co.kr/learn/courses/30/lessons/67258

import collections
def solution(gems):
    dic = {val : idx for idx, val in enumerate(collections.Counter(gems))}
    keys = list(dic.keys())
    answer, counts, start = [1, len(gems)], [0 for _ in range(len(dic))], 0
    for i, g in enumerate(gems):
        if g in keys:
            keys.remove(g)
        counts[dic[g]] += 1
        while len(keys) == 0:
            if answer[1] - answer[0] > i - start:
                answer = [start + 1, i + 1]
            counts[dic[gems[start]]] -= 1
            if counts[dic[gems[start]]] == 0:
                keys.append(gems[start])
            start += 1
    return answer