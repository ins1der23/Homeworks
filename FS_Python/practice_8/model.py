phone_book = []
path = 'FS_Python\practice_8\phones.txt'


def open_file():
    with open(path, 'r', encoding='UTF-8') as file:
        data = file.readlines()
    for contact in data:
        user_id, name, phone, comment, *_ = contact.strip().split(':')
        phone_book.append({'id': user_id, 'name': name, 'phone': phone, 'comment': comment})

def save_file():
    data=''
    for contact in phone_book:
        data += f"{contact.get('id')}:{contact.get('name')}:{contact.get('phone')}:{contact.get('comment')}\n"
    with open(path, 'w', encoding='UTF-8') as file:
        file.write(data)

def check_id():
    uid_list = []
    for contact in phone_book:
        uid_list.append(int(contact.get('id')))
    return {'id': max(uid_list) + 1}

def add_contact(new: dict):
    new.update(check_id())
    phone_book.append(new)


def search(word: str) -> list[dict]:
    result = []
    for contact in phone_book:
        for value in contact.values():
            if word.lower() in value.lower():
                result.append(contact)
                break
    return result


def change(index: int, new: dict[str, str]):
    for key, field in new.items():
        if field != '':
            phone_book[index - 1][key] = field

def get_max_id():
    uid_list = []
    for contact in phone_book:
        uid_list.append(int(contact.get('id')))
    return int(max(uid_list))

def delete(index: int):
    del phone_book[index-1]

def reassign_id():
    for contact in phone_book:
        contact['id'] = str(phone_book.index(contact) + 1)
