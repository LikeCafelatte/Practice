# [1차] 프렌즈4블록
# https://school.programmers.co.kr/learn/courses/30/lessons/17679

def solution(m, n, board):
    new_board = []
    for l in zip(*board):
        new_board.append(''.join(l))
    while True:
        backup = []
        isCompleted = True
        for i in range(n - 1):
            for j in range(m - 1):
                temp = new_board[i][j]
                if temp == '0':
                    continue
                if new_board[i + 1][j] == temp and new_board[i][j + 1] == temp and new_board[i + 1][j + 1] == temp:
                    backup.extend([(i, j), (i + 1, j), (i, j + 1), (i + 1, j + 1)])
                    isCompleted = False
        temp_board = ['' for _ in range(n)]
        for i in range(n):
            for j in range(m):
                if not (i, j) in set(backup):
                    temp_board[i] += new_board[i][j]
        for i in range(n):
            new_board[i] = temp_board[i].zfill(m)
        if isCompleted:
            break
    answer = sum([sum(1 for n in b if n == '0') for b in new_board])
    return answer
