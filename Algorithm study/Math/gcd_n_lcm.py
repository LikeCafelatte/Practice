# 최대공약수와 최소공배수
# https://school.programmers.co.kr/learn/courses/30/lessons/12940

def solution(n, m):
    gcd = lambda a, b : b if a % b == 0 else gcd(b, a % b)
    return [gcd(max(n, m), min(n, m)), n * m // gcd(max(n, m), min(n, m))]