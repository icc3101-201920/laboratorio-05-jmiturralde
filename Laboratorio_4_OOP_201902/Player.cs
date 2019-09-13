using Laboratorio_4_OOP_201902.Cards;
using Laboratorio_4_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_4_OOP_201902
{
    public class Player
    {
        //Constantes
        private const int LIFE_POINTS = 2;
        private const int START_ATTACK_POINTS = 0;

        //Static
        private static int idCounter;

        //Atributos
        private int id;
        private int lifePoints;
        private int attackPoints;
        private Deck deck;
        private Hand hand;
        private Board board;
        private SpecialCard captain;

        //Constructor
        public Player()
        {
            LifePoints = LIFE_POINTS;
            AttackPoints = START_ATTACK_POINTS;
            Deck = new Deck();
            Hand = new Hand();
            Id = idCounter++;
        }

        //Propiedades
        public int Id { get => id; set => id = value; }
        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }
            set
            {
                this.lifePoints = value;
            }
        }
        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }
        public Deck Deck
        {
            get
            {
                return this.deck;
            }
            set
            {
                this.deck = value;
            }
        }
        public Hand Hand
        {
            get
            {
                return this.hand;
            }
            set
            {
                this.hand = value;
            }
        }
        public Board Board
        {
            get
            {
                return this.board;
            }
            set
            {
                this.board = value;
            }
        }
        public SpecialCard Captain
        {
            get
            {
                return this.captain;
            }
            set
            {
                this.captain = value;
            }
        }

        //Metodos
        public void DrawCard(int cardId = 0)
        {
            if (cardId.GetType().Name == "CombarCard")
            {
                CombatCard card = (CombatCard)deck.Cards[cardId];
                CombatCard NewCard = new CombatCard(card.Name, card.Type, card.Effect, card.AttackPoints, card.Hero);
                Hand.AddCard(NewCard);
                Deck.DestroyCard(cardId);
            }
            else
            {
                SpecialCard card = (SpecialCard)deck.Cards[cardId];
                SpecialCard NewCard = new SpecialCard(card.Name, card.Type, card.Effect);
                Hand.AddCard(NewCard);
                Deck.DestroyCard(cardId);
            }
        }
        public void PlayCard(int cardId, EnumType buffRow = EnumType.None)
        {
            if (cardId.GetType().Name == "CombatCard")
            {
                CombatCard card = (CombatCard)hand.Cards[cardId];
                CombatCard cardPlayed = new CombatCard(card.Name, card.Type, card.Effect, card.AttackPoints, card.Hero);
                Board.AddCard(cardPlayed, id, cardPlayed.Type);

                Hand.DestroyCard(cardId);
            }
            else
            {
                SpecialCard card = (SpecialCard)hand.Cards[cardId];
                SpecialCard cardPlayed = new SpecialCard(card.Name, card.Type, card.Effect);

                if (cardPlayed.Type == EnumType.buff || cardPlayed.Type == EnumType.bufflongRange || cardPlayed.Type == EnumType.buffmelee || cardPlayed.Type == EnumType.buffrange)
                {
                    Board.AddCard(cardPlayed, id, EnumType);

                    Hand.DestroyCard(cardId);

                }
                if (cardPlayed.Type == EnumType.weather)
                {
                    Board.AddCard(cardPlayed, id, cardPlayed.Type);

                    Hand.DestroyCard(cardId);
                }

            }
           
        }
        public void ChangeCard(int cardId)
        {
            /* Debe cambiar la carta en la posicion cardId de la mano por una carta aleatoria del mazo.
                1- Defina si la carta a cambiar de la mano es CombatCard o SpecialCard. Luego (Esto permite cambiar la referencia):
                        1.1- Asigne una variable a la carta a cambiar de la mano, ejemplo, CombatCard card = hand.Cards[cardId]
                        1.2- Cree una CombatCard o SpecialCard (dependiendo del caso) con los valores de la carta de la mano a cambiar.
                2- Elimine la carta de la mano
                3- Implemente Random
                4- Cree una variable que obtenga un numero aleatorio dentro del total de cartas del mazo.
                5- Obtenga la carta aleatoria del mazo (puede utilizar el método DrawCard) y cree una nueva carta con sus valores. Agreguela a la mano. 
                6- Elimine la carta aleatoria escogida del mazo.
                7- Agregue la carta original de la mano al mazo.
            */
            throw new NotImplementedException();
        }

        public void FirstHand()
        {
            /*Debe obtener 10 cartas aleatorias del mazo y asignarlas a la mano.
            Utilice el metodo DrawCard con 10 numeros de id aleatorios.
            */
            throw new NotImplementedException();
        }

        public void ChooseCaptainCard(SpecialCard captainCard)
        {
            Captain = captainCard;
        }

    }
}
