# k진수에서 소수 개수 구하기
# https://school.programmers.co.kr/learn/courses/30/lessons/92335

def solution(n, k):
    k_base = ""
    while n > 0:
        n, mod = divmod(n, k)
        k_base = str(mod) + k_base
    nums = [int(num) for num in k_base.split('0') if len(num) > 0]
    return len([num for num in nums if isPrime(num)])
def isPrime(num):
    if num == 1:
        return False
    if num in [2, 3]:
        return True
    for i in range(2, int(num ** 0.5) + 1):
        if num % i == 0:
            return False
    return True