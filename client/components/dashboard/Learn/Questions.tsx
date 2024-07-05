"use client";

import Image from "next/image";
import { useState } from "react";
import { useRouter } from "next/navigation";
import { getCorrectAnswer } from "@/lib/actions";
import { QuestionsType } from "@/types/module-types";

const Questions = ({
  questions,
  modulId,
}: {
  questions: QuestionsType[];
  modulId: number;
}) => {
  const [questionsCount, setQuestionsCount] = useState(0);
  const [selectedAnswer, setSelectedAnswer] = useState<number | null>(null);
  const [correctAnswer, setCorrectAnswer] = useState<number | null>(null);
  const [nextButtonShow, setNextButtonShow] = useState(false);
  const router = useRouter();

  const chooseAnswerClickHandler = async (id: number) => {
    const isCorrect = await getCorrectAnswer(id);
    setSelectedAnswer(id);
    setCorrectAnswer(isCorrect ? id : null);
    setNextButtonShow(true);
  };

  const getAnswerClassName = (index: number) => {
    if (selectedAnswer === null)
      return "p-4 bg-[#1CB0F6] text-white rounded-2xl text-[20px] cursor-pointer";
    if (selectedAnswer === index && correctAnswer === index)
      return "p-4 bg-green-500 text-white rounded-2xl text-[20px]";
    if (selectedAnswer === index && correctAnswer !== index)
      return "p-4 bg-red-500 text-white rounded-2xl text-[20px]";
    if (correctAnswer === index)
      return "p-4 bg-green-500 text-white rounded-2xl text-[20px]";
    return "p-4 bg-gray-400 text-white rounded-2xl text-[20px]";
  };

  return (
    <main className="p-8 mb-28">
      <section>
        <div className="flex flex-col m-auto gap-4 max-w-[600px] xl:w-[600px] w-auto">
          <Image
            src={`http://192.168.0.20:5141${questions[questionsCount]?.imagePath}`}
            alt="Question"
            width={600}
            height={250}
            className="h-[250px] rounded-lg"
            priority
          />
          <p className="text-[32px] font-semibold text-center">
            {questions[questionsCount]?.description}
          </p>
          {questions[questionsCount]?.answers.map((answer) => (
            <div
              onClick={() => chooseAnswerClickHandler(answer.id)}
              key={answer.id}
              className={getAnswerClassName(answer.id)}
            >
              {answer.description}
            </div>
          ))}
          {nextButtonShow && (
            <button
              onClick={() => {
                if (questionsCount !== 2) {
                  setNextButtonShow(false);
                  setSelectedAnswer(null);
                  setCorrectAnswer(null);
                  setQuestionsCount(questionsCount + 1);
                } else {
                  router.push(`/dashboard/learn/${modulId}`);
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
