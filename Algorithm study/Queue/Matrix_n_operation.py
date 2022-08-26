x = 0; y = 0
def solution(rc, operations):
    answer = rc
    x = len(rc[0]); y = len(rc)
    operation = {"Rotate" : Rotation, "ShiftRow": ShiftRow}
    for oper in operations:
        answer = operation[oper](answer)
    return answer
def Rotation(table):
    origin_point = table[0][0]
    for i in range(1, x):
        table[i - 1][0] = table[i][0]
        
    for i in range(1, y):
        table[-1][i - 1]= table[-1][i]

    for i in range(1, x):
        table[x - i][-1] = table[x - i - 1][-1]
        
    for i in range(1, y):
        table[0][y - i] = table[0][y - i - 1]
    table[0][1] = origin_point
    return table
def ShiftRow(table):
    table.insert(0, table.pop())
    return table
    
def solution(rc, operations):
    answer = rc
    operation = {"Rotate" : Rotation, "ShiftRow": ShiftRow}
    for oper in operations:
        answer = operation[oper](answer)
    return answer
def Rotation(table):
    origin_point = table[0][0]
    for i in range(1, len(table)):
        table[i - 1][0] = table[i][0]
        
    for i in range(1, len(table[-1])):
        table[-1][i - 1]= table[-1][i]

    for i in range(1, len(table)):
        table[len(table) - i][-1] = table[len(table) - i - 1][-1]
        
    for i in range(1, len(table[0])):
        table[0][len(table[0]) - i] = table[0][len(table[0]) - i - 1]
    table[0][1] = origin_point
    return table
def ShiftRow(table):
    table.insert(0, table.pop())
    return table

from collections import deque
def solution(rc, operations):
    answer = deque([deque(dq) for dq in rc])
    operation = {"Rotate" : Rotate, "ShiftRow": ShiftRow}
    for oper in operations:
        answer = operation[oper](answer)
    return list([list(dq) for dq in answer])
def Rotate(table):
    for i in range(1, len(table)):
        table[i - 1].appendleft(table[i].popleft())
    for i in range(1, len(table)):
        table[len(table) - i].append(table[len(table) - i - 1].pop())
    return table
def ShiftRow(table):
    table.appendleft(table.pop())
    return table

from collections import deque
def solution(rc, operations):
    answer = deque([deque(dq) for dq in rc])
    operation = {"Rotate" : Rotate, "ShiftRow": ShiftRow}
    for oper in operations:
        answer = operation[oper](answer)
    return list([list(dq) for dq in answer])
def Rotate(table):
    for i in range(1, len(table)):
        table[i - 1].appendleft(table[i].popleft())
        table[len(table) - i].append(table[len(table) - i - 1].pop())
    return table
def ShiftRow(table):
    table.rotate(1)
    return table

from collections import deque
def solution(rc, operations):
    answer = deque([deque(dq) for dq in rc])
    operation = {"Rotate" : Rotate, "ShiftRow": ShiftRow}
    backup = "Backup"
    count = 0
    for i, oper in zip(range(len(operations)), operations):
        if backup != oper and i > 0:
            answer = operation[backup](answer, count)
            count = 0
        if i == len(operations) - 1:
            count += 1
            answer = operation[oper](answer, count)
        count += 1
        backup = oper
    return list([list(dq) for dq in answer])
def Rotate(table, count):
    length = len(table) * 2 + len(table[0]) * 2 - 4
    count = count % length if count < length // 2 else (count % length - length)
    if count > 0:
        for i in range(1, len(table) - 1 + count):
            table[max(0, i - count)].appendleft(table[min(len(table) - 1, i)].popleft())
            table[min(len(table) - 1, len(table) - i - 1 + count)].append(table[max(0, len(table) - i - 1)].pop())
    else:
        for i in range(1, len(table) - 1 - count):
            table[max(0, i + count)].append(table[min(len(table) - 1, i)].pop())
            table[min(len(table) - 1, len(table) - i - 1 - count)].appendleft(table[max(0, len(table) - i - 1)].popleft())
    return table
def ShiftRow(table, count):
    table.rotate(count % len(table) if count < len(table) // 2 else (count % len(table) - len(table)))
    return table
