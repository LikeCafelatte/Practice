# 파괴되지 않은 건물
# https://school.programmers.co.kr/learn/courses/30/lessons/92344

def solution(board, skill):
    N, M = len(board), len(board[0])
    effect = [[0 for _ in range(M + 2)] for _ in range(N + 2)]
    answer = 0
    for type, r1, c1, r2, c2, degree in skill:
        degree *= 1 if type == 2 else -1
        effect[r1][c1] += degree
        effect[r1][c2 + 1] -= degree
        effect[r2 + 1][c1] -= degree
        effect[r2 + 1][c2 + 1] += degree
    for i in range(N):
        for j in range(M):
            effect[i][j] += effect[i][j-1] + effect[i-1][j] - effect[i-1][j-1]
            answer += 1 if board[i][j] + effect[i][j] > 0 else 0
    return answer