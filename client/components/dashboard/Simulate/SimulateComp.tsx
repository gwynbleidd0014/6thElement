"use client";

import Image from "next/image";
import cardImage from "../../../public/assets/images/card-image.png";
import { useRouter } from "next/navigation";

const simulateData = [
  {
    image: cardImage,
    title: "Financing Basics",
  },
  {
    image: cardImage,
    title: "Cryptography Basics",
  },
  {
    image: cardImage,
    title: "NFT Basics",
  },
  {
    image: cardImage,
    title: "Financing Basics",
  },
];

const SimulateComp = () => {
  const router = useRouter();
  const onSimulateCardClickHandler = (index: number) => {
    router.push(`/dashboard/simulate/${index}`);
  };

  return (
    <main className="p-8 pt-0 mb-28 xl:mb-0">
      <section>
        <div className="flex flex-col items-center p-6 text-center">
          <h1 className="text-[40px] font-bold">Try Simulations</h1>
        </div>
        <div className="flex flex-col m-auto gap-4 xl:w-[50%]">
          {simulateData.map((sim, index) => (
            <div
              onClick={() => onSimulateCardClickHandler(index)}
              key={index}
              className="flex flex-col justify-between items-center bg-white dark:bg-gray hover:shadow-lg transition-transform transform sm:hover:scale-105 cursor-pointer"
            >
              <Image
                src={sim.image}
                alt="card image"
                className="w-[500px] h-[200px] object-cover rounded-lg"
                priority
              />
              <h2 className="p-2 text-[24px] font-bold text-center">
                {sim.title}
              </h2>
            </div>
          ))}
        </div>
      </section>
    </main>
  );
};

export default SimulateComp;
