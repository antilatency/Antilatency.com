using Csml;
using static Hardware.TrackingAreaFloor_Assets;

partial class Hardware : Scope {

    public static Material TrackingAreaFloor_ru => new Material(
            "Напольная зона трекинга 10м²",
            TrackingAreaFloor_Assets.TrackingAreaFloorProduct0,
             $"Зона трекинга состоит из специальных лент с ИК-маркерами, мягкой плитки и коннекторов. {Hardware.Alt} определяет своё положение в пространстве, анализируя расположение маркеров."
             )
            [new ToDo("Заменить картинку. На этой маркеры не на месте", true)]
            [new Section("Точное расположение маркеров")
                [$"Маркеры фиксируются в отверстиях напольной плитки, которые нарезаются с точностью до миллиметра. Это гарантирует надёжную фиксацию маркером и точное их расположение."]
            ]
            
            [new Section("Ультра-плоские провода и коннекторы")
                [$"Для подведения питания к ИК-маркерам мы разработали специальные ультра-плоские провода высотой в 1 мм. Они идут в комплекте с набором коннекторов."] 
            ]

            [new Section("Мягкое безопасное покрытие") 
                [$"Зона трекинга собирается из мягких и плотных плиток. На такой поверхности вы можете безопасно играть и активно двигаться."]
            ]

            [new Section("Легко собрать")
                [$"Плитки удобно соединяются между собой по принципу паззла. Даже один человек без специальной подготовки может собрать зону любого размера."] 
            ]

            [new Section("Зелёный LED-индикатор")
                [$"Каждый маркер имеет дополнительный LED-индикатор. Если маркер включён, он горит зелёным."] 
            ]

            [new Section("Стандартный комплект")

                [new UnorderedList()
                    [$"Лента с маркерами Reference bar - 4 шт."]
                ]
                [new UnorderedList()
                    [$"Соединительная лента Х0 - 3 шт."]
                ]
                [new UnorderedList()
                    [$"Соединительная лента Х1 - 1 шт."]
                ]  
                [new UnorderedList()
                    [$"Лента питания Power bar - 1 шт."]
                ]
                [new UnorderedList()
                    [$"Коннектор Straight - 3 шт."]
                ]
                [new UnorderedList()
                    [$"Коннектор Corner - 3 шт."]
                ]
                [new UnorderedList()
                    [$"Коннектор T - 1 шт."]
                ]
                [new UnorderedList()
                    [$"Коннектор Cross - 1 шт."]
                ]
                [new UnorderedList()
                    [$"Блок питания - 1 шт."]
                ]
                [new Warning()
                    [$"Обратите внимание, кабель питания не включён в комплект."]
                ]
                [new UnorderedList()
                    [$"Напольные плитки - 20 плиток без отверстий, 4 плитки с одним отверстием и 4 плитки с двумя отверстиями."]
                ]

            ]

            [new Section("Техническая спецификация")
                [new Table(2)
                    [$"Длина волны ИК-маркера"][$"850 нм"]
                    [$"Индикация ИК-маркера"][$"Green LED"]
                    [$"Напольное покрытие"][@$"Размер одной напольной плитки - 0.6 x 0.6 x 0.01 м.
                                        Количество напольных плиток в комплекте - 28 шт.
                                        Общая площадь напольных плиток из 1 комплекта - 10.08 м²"]
                    [$"Блок питания"][@$"Выходное напряжение - 15В
                                       Количество лент с маркерами, подключаемых к 1 блоку питания - до 10 шт."]
                    [$"Размер в упаковке"][$"{Dimensions} мм"]
                    [$"Вес в упаковке"][$"{Weight} кг"]
                ]
            ]

        ;
}