import Image from "next/image";
import simulation from "../../../public/assets/images/simulation1.jpg";

const SimulateDetailsComp = () => {
  return (
    <main className="p-8 pt-0 mb-28 xl:mb-0">
      <section>
        <div className="flex flex-col items-center p-6 text-center">
          <h1 className="text-[40px] font-bold">Try Simulation</h1>
        </div>
        <div className="flex items-center justify-center w-full">
          <Image
            src={simulation}
            alt="simulation"
            className="w-[400px] h-auto rounded-xl"
          />
        </div>
      </section>
    </main>
  );
};

export default SimulateDetailsComp;
