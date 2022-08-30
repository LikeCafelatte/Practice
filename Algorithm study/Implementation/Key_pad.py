def solution(numbers, hand):
    answer = ''; L = 10; R = 12
    for n in numbers:
        n = n if n != 0 else 11
        if n in [2, 5, 8, 11]:
            if sum(divmod(abs(n - L), 3)) < sum(divmod(abs(n - R), 3)):
                answer += 'L'; L = n
            elif sum(divmod(abs(n - L), 3)) > sum(divmod(abs(n - R), 3)):
                answer += 'R'; R = n
            else:
                answer += hand[0].upper();
                (L, R) = (n, R) if hand == "left" else (L, n)
        else:
            if n in [1, 4, 7]:
                answer += 'L'; L = n
            else:
                answer += 'R'; R = n
    return answer