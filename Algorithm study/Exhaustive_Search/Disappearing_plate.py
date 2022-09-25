# 사라지는 발판
# https://school.programmers.co.kr/learn/courses/30/lessons/92345

import itertools
def solution(board, aloc, bloc):
    stack, count, answer = [], 0, 0
    stack.append([aloc[:], bloc[:], board[:], count])
    while stack:
        aloc, bloc, board, count = stack.pop()
        print(aloc, bloc, board, count)
        if aloc == bloc:
            count = count + 1 if count > 0 else 0
            continue
        temp = [[col for col in row] for row in board]
        temp_aloc = []
        i, j = aloc
        if temp[i][j]: temp[i][j] = 0
        else:
            answer = max(count, answer)
            continue
        if i > 0 and board[i - 1][j] > 0: temp_aloc.append([i - 1, j])
        if i < len(board) - 1 and board[i + 1][j] > 0: temp_aloc.append([i + 1, j])
        if j > 0 and board[i][j - 1] > 0: temp_aloc.append([i, j - 1])
        if j < len(board[0]) - 1 and board[i][j + 1] > 0: temp_aloc.append([i, j + 1])
        temp_bloc = []
        i, j = bloc
        if temp[i][j]: temp[i][j] = 0
        else:
            count += 1
            answer = max(count, answer)
            continue
        if i > 0 and board[i - 1][j] > 0: temp_bloc.append([i - 1, j])
        if i < len(board) - 1 and board[i + 1][j] > 0: temp_bloc.append([i + 1, j])
        if j > 0 and board[i][j - 1] > 0: temp_bloc.append([i, j - 1])
        if j < len(board[0]) - 1 and board[i][j + 1] > 0: temp_bloc.append([i, j + 1])
        print(temp_aloc)
        print(temp_bloc)
        if not(temp_aloc and temp_bloc):
            answer = max(count, answer)
            continue
        for a, b in itertools.product(temp_aloc, temp_bloc):
            stack.append([a, b, temp, count + 2])
            print(a, b)
    return answer