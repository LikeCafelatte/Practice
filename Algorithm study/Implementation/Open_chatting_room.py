def solution(record):
    logs = [log.split(' ') for log in record]
    uids = {}
    for log in logs:
        if log[0] != "Leave":
            uids[log[1]] = log[2]
    result = [f"{uids[log[1]]}님이 들어왔습니다." if log[0] == "Enter" else f"{uids[log[1]]}님이 나갔습니다." for log in logs if log[0] != "Change"]
    return result