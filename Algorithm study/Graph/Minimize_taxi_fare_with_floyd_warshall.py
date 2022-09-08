def solution(n, s, a, b, fares):
    INF = 2000000000
    fares_table = [[INF for _ in range(n + 1)] for _ in range(n + 1)]
    for fare in fares:
        fares_table[fare[0]][fare[1]] = fare[2]
        fares_table[fare[1]][fare[0]] = fare[2]
    for i in range(n + 1):
        fares_table[i][i] = 0
    for k in range(1, n + 1):
        for i in range(1, n + 1):
            for j in range(1, n + 1):
                fares_table[i][j] = min(fares_table[i][j], fares_table[i][k] + fares_table[k][j])
    return min([fares_table[s][i] + fares_table[i][a] + fares_table[i][b]for i in range(1, n + 1)])
