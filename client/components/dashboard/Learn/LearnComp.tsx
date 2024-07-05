"use client";

import { ModuleData } from "@/types/module-types";
import Image from "next/image";
import { useRouter } from "next/navigation";

const LearnComp = ({ moduleData }: { moduleData: ModuleData[] }) => {
  const router = useRouter();

  const onModluleClickHandler = (index: number) => {
    router.push(`/dashboard/learn/${index}`);
  };

  return (
    <main className="p-8 pt-0 mb-28 xl:mb-0">
      <section>
        <div className="flex flex-col items-center p-6 text-center">
          <h1 className="text-[40px] font-bold">Choose your module</h1>
        </div>
        <div className="max-w-screen-xl mx-auto grid grid-cols-1 md:grid-cols-2 xl:grid-cols-4 gap-2">
          {moduleData?.map((item) => (
            <div
              key={item.id}
              onClick={() => onModluleClickHandler(item.id)}
              className="p-4 flex flex-col justify-between items-center w-full bg-white dark:bg-gray hover:shadow-lg transition-transform transform sm:hover:scale-105 cursor-pointer xl:mt-[150px]"
            >
              <Image
                src={`http://192.168.0.20:5141${item.imagePath}`}
                alt={item.name}
                width={200}
                height={200}
                className="w-[200px] h-[200px] object-cover rounded-lg"
                priority
              />
              <h2 className="p-2 text-[24px] font-bold text-center">
                {item.name}
              </h2>
            </div>
          ))}
        </div>
      </section>
    </main>
  );
};

export default LearnComp;
