# 소수 찾기
# https://school.programmers.co.kr/learn/courses/30/lessons/12921?language=python3

def solution(n):
    primes = [2]
    for i in range(2, n + 1):
        for prime in primes:
            if i % prime == 0:
                break
            if prime > int(i ** 0.5):
                break
        if i % prime != 0:
            primes.append(i)
    return len(primes)