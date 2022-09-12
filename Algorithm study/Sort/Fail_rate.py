import collections
def solution(N, stages):
    stagnant = collections.Counter(sorted(stages))
    reached = {i: len(stages) for i in range(1, N + 1)}
    for key in reached.keys():
        if key < N:
            reached[key + 1] = reached[key] - stagnant[key]
        reached[key] = stagnant[key] / reached[key] if reached[key] != 0 else 0
    return list(dict(sorted(reached.items(), key = lambda item : item[1], reverse = True)).keys())