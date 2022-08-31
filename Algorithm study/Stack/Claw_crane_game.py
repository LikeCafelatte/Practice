def solution(board, moves):
    new_board = [[b[i] for b in reversed(board) if b[i] > 0] for i in range(len(board[0]))]; q = []; pickup = 0
    for move in moves:
        if len(new_board[move - 1]) > 0:
            pickup += 1; temp = new_board[move - 1].pop(); q.append(temp) if len(q) == 0 or q[-1] != temp else q.pop()
    return pickup - len(q)
