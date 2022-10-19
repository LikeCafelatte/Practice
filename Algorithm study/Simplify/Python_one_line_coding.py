# 자연수 뒤집어 배열로 만들기
# https://school.programmers.co.kr/learn/courses/30/lessons/12932

def solution(n):
    return list(reversed([int(s) for s in str(n)]))

# 평균 구하기
# https://school.programmers.co.kr/learn/courses/30/lessons/12944

def solution(arr):
    return sum(arr)/len(arr)

# 정수 내림차순으로 배치하기
# https://school.programmers.co.kr/learn/courses/30/lessons/12933

def solution(n):
    return int("".join(sorted(str(n), reverse = True)))

# 문자열 내 p와 y의 개수
# https://school.programmers.co.kr/learn/courses/30/lessons/12916

def solution(s):
    return s.lower().count('p') == s.lower().count('y')

# 최댓값과 최솟값
# https://school.programmers.co.kr/learn/courses/30/lessons/12939

def solution(s):
    return str(min([int(n) for n in s.split(' ')])) + " " + str(max([int(n) for n in s.split(' ')]))

# 하샤드 수
# https://school.programmers.co.kr/learn/courses/30/lessons/12947

def solution(x):
    return x % sum(map(int, str(x))) == 0

solution = lambda x : int(x)


# 이상한 문자 만들기
# https://school.programmers.co.kr/learn/courses/30/lessons/12930

def solution(s):
    return ' '.join(''.join([val.upper() if i % 2 == 0 else val.lower() for i, val in enumerate(word)]) for word in s.split(' '))


# 시저 암호
# https://school.programmers.co.kr/learn/courses/30/lessons/12926

def solution(s, n):
    return ' '.join(''.join(chr((ord(c) + n - 65) % 26 + 65) if 65 <= ord(c) < 91  else chr((ord(c) + n - 97) % 26 + 97) for c in w) for w in s.split(' '))


# [1차] 비밀지도
# https://school.programmers.co.kr/learn/courses/30/lessons/17681

def solution(n, arr1, arr2):
    return [''.join('#' if int(a) else ' ' for a in bin(arr1[i]|arr2[i])[2:].rjust(n, '0')) for i in range(n)]


# 문자열 내 마음대로 정렬하기
# https://school.programmers.co.kr/learn/courses/30/lessons/12915

def solution(strings, n):
    return sorted(sorted(strings), key = lambda x : x[n])


# 서울에서 김서방 찾기
# https://school.programmers.co.kr/learn/courses/30/lessons/12919

def solution(seoul):
    return f'김서방은 {seoul.index("Kim")}에 있다'


# 핸드폰번호 가리기
# https://school.programmers.co.kr/learn/courses/30/lessons/12948

def solution(phone_number):
    return '*' * (len(phone_number) - 4) + phone_number[-4:]


# 나누어 떨어지는 숫자배열
# https://school.programmers.co.kr/learn/courses/30/lessons/12910

def solution(arr, divisor):
    return [num for num in sorted(arr) if num % divisor == 0] or [-1]


# 제일 작은 수 제거하기
# https://school.programmers.co.kr/learn/courses/30/lessons/12935

def solution(arr):
    return arr[:arr.index(min(arr))] + arr[arr.index(min(arr)) + 1:] or [-1]

# 수박수박수박수박수박수?
# https://school.programmers.co.kr/learn/courses/30/lessons/12922

def solution(n):
    return '수박' * (n // 2) + '수' * (n % 2)


# 가운데 글자 가져오기
# https://school.programmers.co.kr/learn/courses/30/lessons/12903

def solution(s):
    return s[:len(s)//2 + 1][-((len(s) + 1) % 2 + 1):]


# 문자열 내림차순으로 배치하기
# https://school.programmers.co.kr/learn/courses/30/lessons/12917

def solution(s):
    return ''.join(sorted(s, reverse = True))


# 문자열 다루기 기본
# https://school.programmers.co.kr/learn/courses/30/lessons/12918

def solution(s):
    return (len(s) == 4 or len(s) == 6) and s.isdigit()


# 행렬의 덧셈
# https://school.programmers.co.kr/learn/courses/30/lessons/12950

def solution(arr1, arr2):
    return list(map(lambda A, B : [a + b for a, b in zip(A, B)], arr1, arr2))


# 직사각형 별찍기
# https://school.programmers.co.kr/learn/courses/30/lessons/12969

a, b = map(int, input().strip().split(' '))
print("\n".join(['*' * a] * b))


# JadenCase 문자열 만들기
# https://school.programmers.co.kr/learn/courses/30/lessons/12951?language=python3#

def solution(s):
    return ' '.join((word[0].upper() + word[1:].lower() if len(word) > 0 else '') for word in s.split(' '))


# 최솟값 만들기
# https://school.programmers.co.kr/learn/courses/30/lessons/12941

def solution(A,B):
    return sum(map(lambda a, b: a * b, sorted(A), sorted(B, reverse = True)))


# x만큼 간격이 있는 n개의 숫자
# https://school.programmers.co.kr/learn/courses/30/lessons/12954

def solution(x, n):
    return list(range(x, x * (n + 1), x)) if x != 0 else [0] * n


# 두 정수사이의 합
# https://school.programmers.co.kr/learn/courses/30/lessons/12912?language=python3

def solution(a, b):
    return sum(range(a, b + 1)) if a < b else sum(range(b, a + 1))


# 최고의 집합
# https://school.programmers.co.kr/learn/courses/30/lessons/12938

def solution(n, s):
    return [-1] if s < n else [s // n] * (n - s % n) + [s // n + 1] * (s % n)


# 기지국 설치
# https://school.programmers.co.kr/learn/courses/30/lessons/12979?language=python3

import math
def solution(n, stations, w):
    return sum(math.ceil((stations[i + 1] - stations[i] - 2 * w - 1) / (2 * w + 1)) for i in range(len(stations) - 1)) + math.ceil(max(0, stations[0] - w - 1) / (2 * w + 1)) + math.ceil(max(0, n - stations[-1] - w) / (2 * w + 1))


# 행렬의 곱셈
# https://school.programmers.co.kr/learn/courses/30/lessons/12949

def solution(arr1, arr2):
    return [[sum(arr1[k][j] * arr2[j][i] for j in range(len(arr2))) for i in range(len(arr2[0]))] for k in range(len(arr1))]