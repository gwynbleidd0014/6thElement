import Image from "next/image";
import cardImage from "../../../public/assets/images/card-image.png";

const SimulateComp = () => {
  return (
    <main className="p-8 pt-0 mb-28 xl:mb-0">
      <section>
        <div className="flex flex-col items-center p-6 text-center">
          <h1 className="text-[40px] font-bold">Try Simulations</h1>
        </div>
        <div className="flex flex-col m-auto gap-4 xl:w-[50%]">
          <div className="flex flex-col justify-between items-center bg-white dark:bg-gray hover:shadow-lg transition-transform transform sm:hover:scale-105 cursor-pointer">
            <Image
              src={cardImage}
              alt="card image"
              className="w-[500px] h-[200px] object-cover rounded-lg"
              priority
            />
            <h2 className="p-2 text-[24px] font-bold text-center">Financing Basics</h2>
          </div>
          <div className="p-4 flex flex-col justify-between items-center bg-white dark:bg-gray hover:shadow-lg transition-transform transform sm:hover:scale-105 cursor-pointer">
            <Image
              src={cardImage}
              alt="card image"
              className="w-[500px] h-[200px] object-cover rounded-lg"
              priority
            />
            <h2 className="p-2 text-[24px] font-bold text-center">Cryptography Basics</h2>
          </div>
          <div className="p-4 flex flex-col justify-between items-center bg-white dark:bg-gray hover:shadow-lg transition-transform transform sm:hover:scale-105 cursor-pointer">
            <Image
              src={cardImage}
              alt="card image"
              className="w-[500px] h-[200px] object-cover rounded-lg"
              priority
            />
            <h2 className="p-2 text-[24px] font-bold text-center">NFT Basics</h2>
          </div>
          <div className="p-4 flex flex-col justify-between items-center bg-white dark:bg-gray hover:shadow-lg transition-transform transform sm:hover:scale-105 cursor-pointer">
            <Image
              src={cardImage}
              alt="card image"
              className="w-[500px] h-[200px] object-cover rounded-lg"
              priority
            />
            <h2 className="p-2 text-[24px] font-bold text-center">Financing Basics</h2>
          </div>
        </div>
      </section>
    </main>
  );
};

export default SimulateComp;
