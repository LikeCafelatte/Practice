# 후보키
# https://school.programmers.co.kr/learn/courses/30/lessons/42890

import itertools
import collections
def solution(relation):
    res = []
    for i in range(len(relation[0])):
        for iter in itertools.combinations(range(len(relation[0])), i + 1):
            temp = [tuple([r[idx] for idx in iter]) for r in relation]
            if collections.Counter(temp).most_common(1)[0][1] == 1:
                res.append(iter)
                
    answer = []
    for r in res:
        for a in answer:
            for c in list(a):
                if not c in list(r):
                    break
            else:
                break
        else:
            answer.append(r)
    return len(answer)
