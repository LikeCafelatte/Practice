import itertools
def solution(expression):
    operators = {'*' : lambda x, y : x * y, '+' : lambda x, y : x + y, '-' : lambda x, y : x - y}
    return max([abs(sol(expression, order, operators, 0)) for order in itertools.permutations([operator for operator in ['*', '+', '-'] if operator in expression])])
def sol(expression, order, operators, idx):
    arr = [exp if exp.isnumeric() else sol(exp, order, operators, idx + 1) for exp in expression.split(order[idx])]
    ans = int(arr[0])
    for num in arr[1:]:
        ans = operators[order[idx]](ans, int(num))
    return ans
