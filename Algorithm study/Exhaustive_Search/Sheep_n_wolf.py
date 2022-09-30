# 양과 늑대
# https://school.programmers.co.kr/learn/courses/30/lessons/92343

def solution(info, edges):
    answer = 0
    nodes = [[] for _ in range(len(info))]
    for i, j in edges:
        nodes[i].append(j)
    stack = [[0, 0, 0, []]]
    while stack:
        node, sheeps, wolves, next_nodes = stack.pop()
        sheeps += info[node] ^ 1
        wolves += info[node]
        for n in nodes[node]:
            next_nodes.append(n)
        if sheeps <= wolves or len(next_nodes) == 0:
            answer = max(answer, sheeps)
            continue
        for n in next_nodes:
            temp = next_nodes[:]
            temp.remove(n)
            stack.append([n, sheeps, wolves, temp])
    return answer