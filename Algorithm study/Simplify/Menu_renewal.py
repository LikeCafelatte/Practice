from itertools import combinations
from collections import Counter
def solution(orders, course):
    answer = []
    for c in course:
        result = Counter()
        for order in orders:
            result += Counter(set(["".join(sorted(com)) for com in combinations(order, c)]))
        count = 0
        for r in result.most_common():
            if r[1] > 1 and (count == 0 or count == r[1]):
                answer.append(r[0])
                count = r[1]
            else:
                break
    return sorted(answer)