import Image from "next/image";
import learnIcon from "../../../public/assets/icons/learnIcon.svg";
import simulateIcon from "../../../public/assets/icons/simulateIcon.svg";
import marketPlaceIcon from "../../../public/assets/icons/marketplaceIcon.svg";
import othersIcon from "../../../public/assets/icons/othersIcon.svg";

const marketData = [
  {
    image: learnIcon,
    title: "TEGETA Sale 5%",
  },
  {
    image: simulateIcon,
    title: "Biblusi book",
  },
  {
    image: marketPlaceIcon,
    title: "MyAuto VIP 1mth",
  },
  {
    image: othersIcon,
    title: "MyHome VIP 1mth",
  },
  {
    image: learnIcon,
    title: "TEGETA Sale 5%",
  },
  {
    image: simulateIcon,
    title: "Biblusi book",
  },
  {
    image: marketPlaceIcon,
    title: "MyAuto VIP 1mth",
  },
  {
    image: othersIcon,
    title: "MyHome VIP 1mth",
  },
  {
    image: learnIcon,
    title: "TEGETA Sale 5%",
  },
  {
    image: simulateIcon,
    title: "Biblusi book",
  },
  {
    image: marketPlaceIcon,
    title: "MyAuto VIP 1mth",
  },
  {
    image: othersIcon,
    title: "MyHome VIP 1mth",
  },
  {
    image: learnIcon,
    title: "TEGETA Sale 5%",
  },
  {
    image: simulateIcon,
    title: "Biblusi book",
  },
  {
    image: marketPlaceIcon,
    title: "MyAuto VIP 1mth",
  },
  {
    image: othersIcon,
    title: "MyHome VIP 1mth",
  },
  {
    image: learnIcon,
    title: "TEGETA Sale 5%",
  },
  {
    image: simulateIcon,
    title: "Biblusi book",
  },
  {
    image: marketPlaceIcon,
    title: "MyAuto VIP 1mth",
  },
  {
    image: othersIcon,
    title: "MyHome VIP 1mth",
  },
  {
    image: learnIcon,
    title: "TEGETA Sale 5%",
  },
  {
    image: simulateIcon,
    title: "Biblusi book",
  },
  {
    image: marketPlaceIcon,
    title: "MyAuto VIP 1mth",
  },
  {
    image: othersIcon,
    title: "MyHome VIP 1mth",
  },
];

const MarketplaceComp = () => {
  return (
    <main className="p-8 pt-0 mb-28 xl:mb-0">
      <section>
        <div className="flex flex-col items-center p-6 text-center">
          <h1 className="text-[40px] font-bold">Marketplace</h1>
        </div>
        <div className="max-w-screen-xl mx-auto grid grid-cols-1 md:grid-cols-3 xl:grid-cols-6 gap-2">
          {marketData.map((item, index) => (
            <div key={index} className="flex flex-col items-center justify-between font-semibold">
              <Image
                src={item.image}
                alt={item.title}
                className="w-[100px] h-[100px]"
              />
              <span>{item.title}</span>
            </div>
          ))}
        </div>
      </section>
    </main>
  );
};

export default MarketplaceComp;
