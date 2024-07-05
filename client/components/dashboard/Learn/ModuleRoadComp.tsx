"use client";

import Image from "next/image";
import React from "react";
import completedIcon from "../../../public/assets/icons/completedIcon.svg";
import startIcon from "../../../public/assets/icons/starIcon.svg";
import { useRouter } from "next/navigation";
import { Chapters } from "@/types/module-types";

const ModuleRoadComp = ({
  chapters,
  title,
}: {
  chapters: Chapters[];
  title: string;
}) => {
  const router = useRouter();

  const onChapterClickHandler = (id: number) => {
    router.push(`/dashboard/learn/questions/${id}`);
  };

  const margins = ["mr-0", "mr-20", "mr-40", "mr-10", "mr-40"];
  const colors = [
    "bg-green-500",
    "bg-gray-400",
    "bg-gray-400",
    "bg-gray-400",
    "bg-gray-400",
  ];
  const icons = [completedIcon, startIcon, startIcon, startIcon, startIcon];
  const shadows = [
    "shadow-green-700",
    "shadow-gray-500",
    "shadow-gray-500",
    "shadow-gray-500",
    "shadow-gray-500",
  ];

  return (
    <main className="p-8 pt-0 mb-28 xl:mb-0">
      <section>
        <div className="flex flex-col items-center p-6 text-center">
          <h1 className="text-[40px] font-bold">{title}</h1>
        </div>
        <div className="pt-8 flex flex-col items-center gap-8">
          {chapters?.map((chapter, index) => (
            <button
              key={chapter.id}
              onClick={() => onChapterClickHandler(chapter.id)}
              className={`w-[100px] h-[70px] rounded-[50%] ${colors[index]} flex flex-col items-center justify-center ${margins[index]} hover:scale-105 shadow-[0_6px_0] ${shadows[index]}`}
            >
              <Image
                src={icons[index]}
                alt="Chapter icon"
                className="w-[50px] h-[50px]"
              />
            </button>
          ))}
        </div>
      </section>
    </main>
  );
};

export default ModuleRoadComp;
