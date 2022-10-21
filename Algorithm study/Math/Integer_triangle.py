# 정수 삼각형
# https://school.programmers.co.kr/learn/courses/30/lessons/43105

def solution(triangle):
    for i in range(len(triangle) - 2, -1, -1):
        for j in range(i + 1):
            triangle[i][j] += max(triangle[i + 1][j], triangle[i + 1][j + 1])
    return triangle[0][0]