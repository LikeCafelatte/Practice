# 등대
# https://school.programmers.co.kr/learn/courses/30/lessons/133500

def solution(n, lighthouse):
    answer = n
    link = [[] for i in range(n + 1)]
    for a, b in lighthouse:
        link[a].append(b)
        link[b].append(a)
    for i in range(1, n + 1):
        states = [0 for _ in range(n + 1)]
        total = 0
        stack = [i]
        while stack:
            poped = stack.pop()
            if states[poped] == 0:
                states[poped] = 1
                for leaf in link[poped]:
                    states[leaf] = 1
                    stack.extend(link[leaf])
                total += 1
        answer = min(answer, total)
    return answer