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