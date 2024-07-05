"use client";

import Image from "next/image";
import learnIcon from "../../../public/assets/icons/learnIcon.svg";
import simulateIcon from "../../../public/assets/icons/simulateIcon.svg";
import marketPlaceIcon from "../../../public/assets/icons/marketplaceIcon.svg";
import othersIcon from "../../../public/assets/icons/othersIcon.svg";
import coin from "../../../public/assets/icons/coin.svg";
import { useState } from "react";
import { AnimatePresence } from "framer-motion";
import Modal from "@/components/UI/Modal";

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
  const [showModal, setShowModal] = useState(false);

  const isClose = () => {
    document.body.style.overflow = "unset";
    setShowModal(false);
  };

  const isOpen = () => {
    document.body.style.overflow = "hidden";
    setShowModal(true);
  };

  return (
    <main className="p-8 pt-0 mb-28 xl:mb-0">
      <AnimatePresence>
        {showModal && <Modal isClose={isClose} />}
      </AnimatePresence>
      <section>
        <div className="flex flex-col items-center p-6 text-center">
          <h1 className="text-[40px] font-bold">Marketplace</h1>
        </div>
        <div className="max-w-screen-xl mx-auto grid grid-cols-1 md:grid-cols-3 xl:grid-cols-6 gap-8">
          {marketData.map((item, index) => (
            <div
              key={index}
              onClick={isOpen}
              className="flex flex-col items-center justify-between font-semibold cursor-pointer"
            >
              <Image
                src={item.image}
                alt={item.title}
                className="w-[100px] h-[100px]"
              />
              <span>{item.title}</span>
              <div className="text-[#1CB0F6] xl:flex items-center text-[20px] font-bold hidden">
                <Image src={coin} alt="coin icon" className="w-10 h-10" />{" "}
                <span>10</span>
              </div>
            </div>
          ))}
        </div>
      </section>
    </main>
  );
};

export default MarketplaceComp;
