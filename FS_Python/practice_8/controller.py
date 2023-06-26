from view import menu, show_contacts, print_message, input_contact, input_return, input_return_int

import model
from view import text


def start():
    while True:
        choice = menu()
        match choice:
            case 1:
                model.open_file()
                print_message(text.open_successful)
            case 2:
                model.save_file()
                print_message(text.save_successful)
            case 3:
                show_contacts(model.phone_book)
            case 4:
                new = input_contact(text.input_new_contact)
                model.add_contact(new)
                model.reassign_id()
                print_message(text.contact_saved(new.get('name')))
            case 5:
                word = input_return(text.search_word)
                result = model.search(word)
                show_contacts(result)
            case 6:
                word = input_return(text.search_word)
                result = model.search(word)
                show_contacts(result)
                upper = model.get_max_id()
                index = input_return_int(text.input_index, upper)
                old_name = model.phone_book[int(index)-1].get('name')
                new = input_contact(text.input_change_contact)
                model.change(int(index), new)
                print_message(text.contact_changed(new.get('name') if new.get('name') else old_name))
            case 7:
                word = input_return(text.delete_word)
                result = model.search(word)
                show_contacts(result)
                upper = model.get_max_id()
                index = input_return_int(text.delete_index, upper)
                name = model.phone_book[int(index)-1].get('name')
                model.delete(index)
                model.reassign_id()
                print_message(text.contact_deleted(name))
            case 8:
                break
