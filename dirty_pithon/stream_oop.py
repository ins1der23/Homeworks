class Whore:
    def __init__ (self, name:str, age:float, price:float):
        self.name = name
        self.__age = age
        self._price = price

    def get_age(self) -> int:
        return self.__age

    def set_age (self, new_age:int):
        self.__age = new_age

natasha = Whore('Natasha', 56, 1350.6)
    
natasha.name = 'Svetlana'
natasha.age = 18
natasha.price = 1600