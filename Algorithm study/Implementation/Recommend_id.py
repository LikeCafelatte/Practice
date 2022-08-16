def solution(new_id):
    answer = ''
    # no.1
    new_id = new_id.lower()
    # no.2
    import re
    new_id = re.sub(r"[^a-zA-Z0-9-_.]","",new_id)
    print(new_id)
    # no.3
    while new_id != new_id.replace("..", ".") :
        new_id = new_id.replace("..", ".")
    # no.4
    if len(new_id) > 0 and new_id[0] == "." :
        new_id = new_id[1:]
    if len(new_id) > 0 and new_id[-1] == "." :
        new_id = new_id[:-1]
    # no.5
    if len(new_id) == 0 :
        new_id = "a"
    # no.6
    if len(new_id) > 15 :
        new_id = new_id[0 : 15]
    if len(new_id) > 0 and new_id[-1] == "." :
        new_id = new_id[:-1]
    # no.7
    while len(new_id) < 3 :
        new_id = new_id + new_id[-1]
    return new_id
