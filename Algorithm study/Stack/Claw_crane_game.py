def solution(board, moves):
    new_board = [[b[i] for b in reversed(board) if b[i] > 0] for i in range(len(board[0]))]; q = []; pickup = 0
    for move in moves:
        if len(new_board[move - 1]) > 0:
            pickup += 1; q.append(new_board[move - 1].pop()) if len(q) == 0 or q[-1] != new_board[move - 1][-1] else q.pop()
    return pickup - len(q)
