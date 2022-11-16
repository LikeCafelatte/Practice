# 모음사전
# https://school.programmers.co.kr/learn/courses/30/lessons/84512

import itertools
def solution(word):
    words = []
    for i in range(1, 6):
        for p in itertools.product('AEIOU', repeat = i):
            words.append(''.join(p))
    words.sort()
    return words.index(word) + 1