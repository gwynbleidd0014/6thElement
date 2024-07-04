"use client";

import Image from "next/image";
import cardImage from "../../../public/assets/images/card-image.png";
import { useState } from "react";
import { useRouter } from "next/navigation";

const questionsData = [
  {
    image: cardImage,
    question: "რა არის ფული?",
    answers: [
      "მხოლოდ ქაღალდის ბანკნოტები",
      "საშუალება ნივთების და მომსახურების შესაძენად",
      "მხოლოდ მონეტები",
    ],
    correct_answer: "საშუალება ნივთების და მომსახურების შესაძენად",
  },
  {
    image: cardImage,
    question: "სად არის უკეთესი ფულის შენახვა?",
    answers: ["ბალიშის ქვეშ", "სათამაშოების ყუთში", "ბანკში ან საფულეში"],
    correct_answer: "ბანკში ან საფულეში",
  },
  {
    image: cardImage,
    question: "რა არის ფულის დაზოგვა?",
    answers: [
      "ფულის დახარჯვა ყველაფერზე, რაც გვინდა",
      "ფულის გვერდზე გადადება მომავლისთვი",
      "ფულის სხვებისთვის მიცემა",
    ],
    correct_answer: "ფულის გვერდზე გადადება მომავლისთვი",
  },
];

const Questions = () => {
  const [questionsCount, setQuestionsCount] = useState(0);
  const [selectedAnswer, setSelectedAnswer] = useState<number | null>(null);
  const [nextButtonShow, setNextButtonShow] = useState(false);
  const router = useRouter();

  const chooseAnswerClickHandler = (index: number) => {
    setSelectedAnswer(index);
    setNextButtonShow(true);
  };

  const isAnswerCorrect = (index: number) => {
    return (
      questionsData[questionsCount].answers[index] ===
      questionsData[questionsCount].correct_answer
    );
  };

  const getAnswerClassName = (index: number) => {
    if (selectedAnswer === null)
      return "p-4 bg-[#1CB0F6] text-white rounded-2xl text-[20px] cursor-pointer";
    if (selectedAnswer === index && isAnswerCorrect(index))
      return "p-4 bg-green-500 text-white rounded-2xl text-[20px]";
    if (selectedAnswer === index && !isAnswerCorrect(index))
      return "p-4 bg-red-500 text-white rounded-2xl text-[20px]";
    if (isAnswerCorrect(index))
      return "p-4 bg-green-500 text-white rounded-2xl text-[20px]";
    return "p-4 bg-gray-400 text-white rounded-2xl text-[20px]";
  };

  return (
    <main className="p-8">
      <section>
        <div className="flex flex-col m-auto gap-4 xl:w-[600px] w-auto">
          <Image
            src={questionsData[questionsCount].image}
            alt="Question"
            className="h-[250px] rounded-lg"
            priority
          />
          <p className="text-[32px] font-semibold text-center">
            {questionsData[questionsCount].question}
          </p>
          {questionsData[questionsCount].answers.map((answer, index) => (
            <div
              onClick={() => chooseAnswerClickHandler(index)}
              key={index}
              className={getAnswerClassName(index)}
            >
              {answer}
            </div>
          ))}
          {nextButtonShow && (
            <button
              onClick={() => {
                if (questionsCount !== 2) {
                  setNextButtonShow(false);
                  setSelectedAnswer(null);
                  setQuestionsCount(questionsCount + 1);
                } else {
                  router.push("/dashboard/learn/0");
                }
              }}
              className="p-4 bg-[#1CB0F6] text-white rounded-2xl text-[26px] font-extrabold"
            >
              {questionsCount === 2 ? "FINISH" : "NEXT"}
            </button>
          )}
        </div>
      </section>
    </main>
  );
};

export default Questions;
