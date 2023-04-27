from clickhouse_driver import Client
import collections


"""
    Прокси класс для работы с базой данных
"""
class db_proxy():
    __client = None
    __is_open = False
    __error_text = ""
    __data = []

    def create(self):
        """
        Создать новое подключение
        """
        self.__error_text = ""
        if self.__is_open == True:
            return self.__client
        
        try:
            self.__client = Client(host='rc1a-7ut3ob6t69958voj.mdb.yandexcloud.net', user='user', password='useruser', port = 9440, database = "dbDashboard", secure = True)
            return self.__client
        except Exception as ex:
            self.__error_text = "Невозможно открыть подключение к базе данных! " + ex.args[0]
            self.__client = None
            return None


    
    @property
    def error_text(self):
        """
        Получить сообщение об ошибке
        """
        return self.__error_text
    

    @property
    def is_error(self):
        """
        Получить флаг о последнем состоянии
        """
        return not self.__error_text == "" 
    

    def get_rows(self, sql, map_type):
        """
        Выполнить SQL запрос и сформировать массив из структур map_type
        """

        if sql == "":
            raise Exception("Некорректно передан параметр sql!")
        
        if map_type is None:
            raise Exception("Некорректно передан параметр map_type!")

        if self.__client is None:
            self.open()

        if self.is_error:
            return
        
        self.__error_text = ""
        try:
            rows = self.__client.execute(query = sql,  with_column_types=True)

            # Формируем словарь: поле / значение
            columns = list(map(lambda x: x[0], rows[-1]))
            for row in rows[0]:
                dict = {}
                column_index = 0
                for column in columns:
                    dict[column] = str(row[column_index])
                    column_index += 1

                self.__data.append(dict)

            # Сконвертируем словарь в массив типа map_type
            objects = []
            for item in self.__data:
                object = map_type()
                is_yes_data = False
                for column in columns:
                    yes_field = hasattr(map_type, column)
                    if yes_field:
                        setattr(object, column, item.value)
                        is_yes_data = True
                    
                if is_yes_data == True:
                    objects.append(object)

            return objects

        except Exception as ex:
            self.__error_text = "Ошибка при выполнении SQL запроса (" + sql + ")  " + ex.args[0]



        

        




    



    



        