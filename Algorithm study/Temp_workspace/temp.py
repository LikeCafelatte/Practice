import sys
sys.setrecursionlimit(10**7)

def solution(m, n, puddles):
    answer = 0
    global basemap
    global reference
    reference = [m, n]
    basemap = [[0] * m for _ in range (n)]
    for i, j in puddles:
        basemap[i - 1][j - 1] = -1
    print(basemap)
    basemap[0][0] = 1
    return dp(n - 1, m - 1)%1000000007

def dp(x, y):
    m, n = reference
    if x < 0 or x > n - 1 or y < 0 or y > m - 1 or basemap[x][y] == -1:
        return 0
    if basemap[x][y] != 0:
        return basemap[x][y]
    else:
        basemap[x][y] = -1
        basemap[x][y] =  dp(x + 1, y) + dp(x - 1, y) + dp(x, y - 1) + dp(x, y + 1)
        return basemap[x][y]



import sys
sys.setrecursionlimit(10**7)

def solution(m, n, puddles):
    answer = 0
    global basemap
    global reference
    reference = [m, n]
    basemap = [[[m * n + 1, 0]] * m for _ in range (n)]
    for i, j in puddles:
        basemap[i - 1][j - 1][0] = -1
    print(basemap)
    print(dp(0, 0, m, n))
    return basemap[n - 1][m - 1][1]%1000000007


def dp(x, y, r, c):
    m, n = reference
    if basemap[x][y][0] > r:
        basemap[x][y] = [r, c]
    elif basemap[x][y][0] == r:
        basemap[x][y][1] += c
    if x == n - 1 and y == m - 1:
        return
    if x < n - 1 and not basemap[x + 1][y][0] < basemap[x][y][0]:
        dp(x + 1, y, basemap[x][y][0] + 1, basemap[x][y][1])
    if x > 0 and not basemap[x - 1][y] < basemap[x][y][0]:
        dp(x - 1, y, basemap[x][y][0] + 1, basemap[x][y][1])
    if y < m - 1 and not basemap[x][y + 1] < basemap[x][y][0]:
        dp(x, y + 1, basemap[x][y][0] + 1, basemap[x][y][1])
    if y > 0 and not basemap[x][y - 1] < basemap[x][y][0]:
        dp(x, y - 1, basemap[x][y][0] + 1, basemap[x][y][1])








def solution(routes):
    answer = 0
    temp = -30001
    for i, o in sorted(routes):
        if i > temp:
            answer += 1
            temp = o
    return answer


def solution(n, k, cmd):
    answer = ''
    idx = k
    delete_list = []
    result = ['O' for _ in range(n)]
    for c in cmd:
        if len(c) > 1:
            c, x = c.split(' ')
            x = int(x)
            if c == 'D':
                for d in sorted(delete_list):
                    if d < idx:
                        continue
                    elif idx < d <= idx + x:
                        x += 1
                    else:
                        break
                idx += x
            elif c == 'U':
                for d in sorted(delete_list, reverse=True):
                    if d > idx:
                        continue
                    elif idx - x <= d < idx:
                        x += 1
                    else:
                        break
                idx -= x
        else:
            if c == 'C':
                delete_list.append(idx)
                result[idx] = 'X'
            elif c == 'Z':
                z = delete_list.pop()
                result[z] = 'O'
    answer = ''.join(result)
    return answer


function solution(n) {
    var answer = 0;
    for(c = 0; c < n; i++){
        let arr = new Array(n)
        let temp = new Array(n)
        temp.fill(0)
        arr.fill(temp)
        for(i = 0; i < n; i++){
            for(j = i; j < n; j++){

            }
        }
        console.log(arr)
    }
    return answer;
}