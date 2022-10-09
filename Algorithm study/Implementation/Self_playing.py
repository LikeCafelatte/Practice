# 혼자 놀기의 달인
# https://school.programmers.co.kr/learn/courses/30/lessons/131130

def solution(cards):
    answer = 0
    cards.insert(0, 0)
    ref = [0 for _ in range(len(cards))]
    ref[0] = 1
    res = []
    while sum(ref) != len(ref):
        idx = 0
        while ref[idx] != 0:
            idx += 1
        groups = []
        while not idx in groups:
            groups.append(idx)
            ref[idx] = 1
            idx = cards[idx]
        res.append(len(groups))
    res.sort(reverse=True)
    if len(res) < 2:
        return 0
    answer = res[0] * res[1]
    return answer