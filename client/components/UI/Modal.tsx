import { motion } from "framer-motion";

const Modal = ({ isClose }: { isClose: () => void }) => {
  return (
    <motion.div
      initial={{ opacity: 0 }}
      animate={{ opacity: 1 }}
      exit={{ opacity: 0 }}
      onClick={isClose}
      className="fixed inset-0 z-50 bg-[#000000bf] opacity-90 flex items-center justify-center"
    >
      <motion.div
        initial={{ scale: 0, rotate: "12.5deg" }}
        animate={{ scale: 1, rotate: "0deg" }}
        exit={{ scale: 0, rotate: "0deg" }}
        onClick={(e) => e.stopPropagation()}
        className="relative z-50 p-8 border border-red rounded-xl bg-white dark:bg-gray dark:border-black"
      >
        <div className="flex items-center flex-col justify-center gap-6">
            <h2 className="text-black text-[20px]">Are you sure? this action is not refundable</h2>
            <button className="uppercase bg-[#1CB0F6] text-white p-4 rounded" onClick={isClose}>Buy now</button>
        </div>
      </motion.div>
    </motion.div>
  );
};

export default Modal;
