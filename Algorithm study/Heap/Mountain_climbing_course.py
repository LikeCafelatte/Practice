# 등산코스 정하기
# https://school.programmers.co.kr/learn/courses/30/lessons/118669

from heapq import heappush, heappop
def solution(n, paths, gates, summits):
    answer = [50001, 10000001]
    intensities = [10000001 for _ in range(n + 1)]
    paths_dict = {i:[] for i in range(n + 1)}
    for i, j, w in paths:
        paths_dict[i].append([j, w])
        paths_dict[j].append([i, w])
    q = []
    for gate in gates:
        intensities[gate] = 0
        for j, w in paths_dict[gate]:
            heappush(q, node(gate, j, w))
    while q:
        n = heappop(q)
        i, j, w = n.i, n.j, n.w
        if w > answer[1]:
            break
        if intensities[j] > 10000000:
            intensities[j] = max(intensities[i], w)
            if j in summits:
                if answer[1] > intensities[j]:
                    answer = [j, intensities[j]]
                elif answer[1] == intensities[j]:
                    answer[0] = min(answer[0], j)
                else:
                    break
                continue
            for path in paths_dict[j]:
                if intensities[path[0]] > 10000000:
                    heappush(q, node(j, path[0], path[1]))
    return answer
class node:
    def __init__(self, i, j, w):
        self.i, self.j, self.w = i, j, w

    def __lt__(self, other):
        if self.w < other.w:
            return True
        elif self.w == other.w and self.j < other.j:
            return True
        else:
            return False